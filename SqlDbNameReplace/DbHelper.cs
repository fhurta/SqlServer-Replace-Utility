using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace SqlDbNameReplace
{
    internal class DbHelper
    {
        //public static async Task

        public static async Task ScanAndReplaceAsync(Database db, string orig, string replacement, Action<string> logger, bool searchOnly)
        {
            await Task.Run(() => ScanAndReplace(db, orig, replacement, logger, searchOnly));
        }

        private static void ScanAndReplace(Database db, string orig, string replacement, Action<string> logger, bool searchOnly)
        {
            logger("Scanning objects..");
            foreach (var dbView in db.Views.OfType<View>().Where(o => !o.IsSystemObject && o.TextMode))
            {
                var str = dbView.TextBody;
                if (str.Contains(orig))
                {
                    if (searchOnly)
                    {
                        logger($"View: [{dbView.Name}]");
                    }
                    else
                    {
                        logger($"Replacing View: [{dbView.Name}]");
                        var updated = str.Replace(orig, replacement);
                        dbView.TextBody = updated;
                        dbView.Alter();
                    }
                }
                else
                {
                    //logger($"skipping View: {dbView.Name}");
                }
            }

            foreach (var sp in db.StoredProcedures.OfType<StoredProcedure>().Where(o => !o.IsSystemObject && o.TextMode))
            {
                var str = sp.TextBody;
                if (str.Contains(orig))
                {
                    if (searchOnly)
                    {
                        logger($"SP: [{sp.Name}]");
                    }
                    else
                    {
                        logger($"Replacing SP: [{sp.Name}]");
                        var updated = str.Replace(orig, replacement);
                        sp.TextBody = updated;
                        sp.Alter();
                    }
                }
                else
                {
                    //logger($"skipping SP: {sp.Name}");
                }
            }

            foreach (var udf in db.UserDefinedFunctions.OfType<UserDefinedFunction>().Where(o => !o.IsSystemObject && o.TextMode))
            {
                var str = udf.TextBody;
                if (str.Contains(orig))
                {
                    if (searchOnly)
                    {
                        logger($"UDF: [{udf.Name}]");
                    }
                    else
                    {
                        logger($"Replacing UDF: [{udf.Name}]");
                        var updated = str.Replace(orig, replacement);
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