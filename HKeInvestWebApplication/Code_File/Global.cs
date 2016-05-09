using System;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Contains my site's global variables.
/// </summary>
public static class GlobalVal
{
    /// <summary>
    /// Global variable storing important stuff.
    /// </summary>
    static string _importantData;

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string ImportantData
    {
        get
        {
            return _importantData;
        }
        set
        {
            _importantData = value;
        }
    }

    public static void reset() { _importantData = null; }
}
