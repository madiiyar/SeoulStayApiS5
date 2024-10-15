using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Modelss;

public partial class DimDate
{
    public long Id { get; set; }

    public DateOnly Date { get; set; }

    public int Year { get; set; }

    public int Quarter { get; set; }

    public int Month { get; set; }

    public string MonthName { get; set; } = null!;

    public int DayOfMonth { get; set; }

    public int DayOfWeek { get; set; }

    public string DayName { get; set; } = null!;

    public bool IsHoliday { get; set; }
}
