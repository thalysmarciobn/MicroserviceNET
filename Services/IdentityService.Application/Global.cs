using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace IdentityService.Application;

public static class Global
{
    [NotNull] public static readonly Assembly Assembly = typeof(Global).Assembly;
}