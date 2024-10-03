using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobGuard.Infrastructure.Postgres.Convertors;

public class ListToStringConverter() : ValueConverter<List<string>, string>(
    v => string.Join('\n', v),
    v => v.Split('\n', StringSplitOptions.None).ToList());
