using System.Text.RegularExpressions;
using Intersect.Framework.Core.GameObjects.Variables;
using Intersect.Server.Database;
using NCalc;

namespace Intersect.Server.Entities.Events;

public static class ExpressionEvaluator
{
    private static readonly Regex TokenRegex = new(
        @"\\(pv|sv|gv|uv)\{([^}]+)\}",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    public static long Evaluate(string expression, Player player)
    {
        if (string.IsNullOrWhiteSpace(expression))
            return 0;

        try
        {
            var resolved = TokenRegex.Replace(expression, match =>
            {
                var prefix = match.Groups[1].Value.ToLower();
                var name   = match.Groups[2].Value;
                long val   = 0;

                switch (prefix)
                {
                    case "pv":
                        Console.WriteLine($"[ExpressionEvaluator] PV Lookup count: {PlayerVariableDescriptor.Lookup.KeyList.Count}");
                        foreach (var key in PlayerVariableDescriptor.Lookup.KeyList)
                        {
                            var v = PlayerVariableDescriptor.Get(key);
                            Console.WriteLine($"[ExpressionEvaluator] PV: Name={v?.Name} TextId={v?.TextId}");
                        }

                        var pvDescriptor = PlayerVariableDescriptor.Lookup.KeyList
                            .Select(id => PlayerVariableDescriptor.Get(id))
                            .FirstOrDefault(v => v != null && string.Equals(v.TextId, name, StringComparison.OrdinalIgnoreCase));
                        if (pvDescriptor != null)
                            val = player.GetVariableValue(pvDescriptor.Id)?.Integer ?? 0;
                        break;

                    case "sv":
                        var svDescriptor = ServerVariableDescriptor.Lookup.KeyList
                            .Select(id => ServerVariableDescriptor.Get(id))
                            .FirstOrDefault(v => v != null && string.Equals(v.TextId, name, StringComparison.OrdinalIgnoreCase));
                        if (svDescriptor != null)
                            val = svDescriptor.Value?.Integer ?? 0;
                        break;

                    case "gv":
                        if (player.Guild != null)
                        {
                            var gvDescriptor = GuildVariableDescriptor.Lookup.KeyList
                                .Select(id => GuildVariableDescriptor.Get(id))
                                .FirstOrDefault(v => v != null && string.Equals(v.TextId, name, StringComparison.OrdinalIgnoreCase));
                            if (gvDescriptor != null)
                                val = player.Guild.GetVariableValue(gvDescriptor.Id)?.Integer ?? 0;
                        }
                        break;

                    case "uv":
                        var uvDescriptor = UserVariableDescriptor.Lookup.KeyList
                            .Select(id => UserVariableDescriptor.Get(id))
                            .FirstOrDefault(v => v != null && string.Equals(v.TextId, name, StringComparison.OrdinalIgnoreCase));
                        if (uvDescriptor != null)
                            val = player.User.GetVariableValue(uvDescriptor.Id)?.Integer ?? 0;
                        break;
                }

                return val.ToString();
            });

            Console.WriteLine($"[ExpressionEvaluator] Original: \"{expression}\" | Resolved: \"{resolved}\"");
            var expr = new Expression(resolved, EvaluateOptions.IgnoreCase);

            expr.EvaluateFunction += (name, args) =>
            {
                switch (name.ToLower())
                {
                    case "pow":
                        args.Result = Math.Pow(
                            Convert.ToDouble(args.Parameters[0].Evaluate()),
                            Convert.ToDouble(args.Parameters[1].Evaluate()));
                        break;
                    case "sqrt":
                        args.Result = Math.Sqrt(Convert.ToDouble(args.Parameters[0].Evaluate()));
                        break;
                    case "floor":
                        args.Result = Math.Floor(Convert.ToDouble(args.Parameters[0].Evaluate()));
                        break;
                    case "ceil":
                        args.Result = Math.Ceiling(Convert.ToDouble(args.Parameters[0].Evaluate()));
                        break;
                    case "abs":
                        args.Result = Math.Abs(Convert.ToDouble(args.Parameters[0].Evaluate()));
                        break;
                    case "min":
                        args.Result = Math.Min(
                            Convert.ToDouble(args.Parameters[0].Evaluate()),
                            Convert.ToDouble(args.Parameters[1].Evaluate()));
                        break;
                    case "max":
                        args.Result = Math.Max(
                            Convert.ToDouble(args.Parameters[0].Evaluate()),
                            Convert.ToDouble(args.Parameters[1].Evaluate()));
                        break;
                    case "log":
                        args.Result = args.Parameters.Length > 1
                            ? Math.Log(
                                Convert.ToDouble(args.Parameters[0].Evaluate()),
                                Convert.ToDouble(args.Parameters[1].Evaluate()))
                            : Math.Log(Convert.ToDouble(args.Parameters[0].Evaluate()));
                        break;
                    case "round":
                        args.Result = Math.Round(Convert.ToDouble(args.Parameters[0].Evaluate()));
                        break;
                }
            };

            var result = expr.Evaluate();
            return Convert.ToInt64(Math.Truncate(Convert.ToDouble(result)));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ExpressionEvaluator] Failed to evaluate \"{expression}\": {ex.Message}");
            return 0;
        }
    }
}