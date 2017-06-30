using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace SqlDbNameReplace
{
    internal class DbHelper
    {
        //public static async Task

        public static async Task ScanAndReplaceAsync(Database db, Regex regex, string replacement, Action<string> logger, bool searchOnly)
        {
            await Task.Run(() => ScanAndReplace(db, regex, replacement, logger, searchOnly));
        }

        private static void ScanAndReplace(Database db, Regex regex, string replacement, Action<string> logger, bool searchOnly)
        {
            logger("Scanning views..");
            foreach (var dbView in db.Views.OfType<View>().Where(o => !o.IsSystemObject && o.TextMode))
            {
                var str = dbView.TextBody;

                if (regex.IsMatch(str))
                {
                    if (searchOnly)
                    {
                        logger($"View: [{dbView.Name}]");
                    }
                    else
                    {
                        logger($"Replacing View: [{dbView.Name}]");
                        var updated = regex.Replace(str, replacement);
                        dbView.TextBody = updated;
                        dbView.Alter();
                    }
                }
                else
                {
                    //logger($"skipping View: {dbView.Name}");
                }
            }

            logger("Scanning SPs..");
            foreach (var sp in db.StoredProcedures.OfType<StoredProcedure>().Where(o => !o.IsSystemObject && o.TextMode))
            {
                var str = sp.TextBody;
                if (regex.IsMatch(str))
                {
                    if (searchOnly)
                    {
                        logger($"SP: [{sp.Name}]");
                    }
                    else
                    {
                        logger($"Replacing SP: [{sp.Name}]");
                        var updated = regex.Replace(str, replacement);
                        sp.TextBody = updated;
                        sp.Alter();
                    }
                }
                else
                {
                    //logger($"skipping SP: {sp.Name}");
                }
            }

            logger("Scanning UDFs..");
            foreach (var udf in db.UserDefinedFunctions.OfType<UserDefinedFunction>().Where(o => !o.IsSystemObject && o.TextMode))
            {
                var str = udf.TextBody;
                if (regex.IsMatch(str))
                {
                    if (searchOnly)
                    {
                        logger($"UDF: [{udf.Name}]");
                    }
                    else
                    {
                        logger($"Replacing UDF: [{udf.Name}]");
                        var updated = regex.Replace(str, replacement);
                        udf.TextBody = updated;
                        udf.Alter();
                    }
                }
                else
                {
                    //logger($"skipping UDF: {udf.Name}");
                }
            }
        }
    }
}