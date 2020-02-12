using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class FaranamView<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public Sso.UMProxy.SsoUser CurrentSsoUser
        {
            get
            {
                return Context.User as Sso.UMProxy.SsoUser;
            }
        }

        public override void Execute()
        {
            base.ExecutePageHierarchy();
        }


        public string getAreaTitle(List<BusinessModel.WarningThresholdModel> model, string guid)
        {
            var warnings = model.Where(x => x.Threshold.NetworkGuid == guid).ToList();
            if (warnings.Count == 0)
            {
                return "";
            }
            string message = "";
            foreach (var warn in warnings)
            {
                message += string.Format("برای استان <strong>{0}</strong> دانشگاه <strong>{1}</strong> شبکه بهداشت <strong>{2}</strong> برای سندرم <strong>{3}</strong> با روش <strong>{4}</strong> هشدار صادر شده است. لطفا دستورالعمل شماره <strong>{5}</strong> را اجرا کنید. ",
                    warn.Threshold.ProvinceName, warn.Threshold.UniversityName, warn.Threshold.NetworkName,
                    warn.Threshold.SyndromicName, warn.Threshold.MethodName, warn.Threshold.SyndromicId) + "<br />";
            }
            return message;
        }

        public string getAreaClass(List<BusinessModel.WarningThresholdModel> model, string guid)
        {
            if (!model.Any(x => x.Threshold.NetworkGuid == guid))
            {
                return "";
            }
            bool hasAbs, hasRel, hasCutoff, hasCuSum;
            hasAbs = model.Any(x => x.Threshold.NetworkGuid == guid && x.Threshold.MethodName.ToLower().Contains("abso"));
            hasRel = model.Any(x => x.Threshold.NetworkGuid == guid && x.Threshold.MethodName.ToLower().Contains("relative"));
            hasCutoff = model.Any(x => x.Threshold.NetworkGuid == guid && x.Threshold.MethodName.ToLower().Contains("cut"));
            hasCuSum = model.Any(x => x.Threshold.NetworkGuid == guid && x.Threshold.MethodName.ToLower().Contains("cusum"));

            /*
            abs = yellow,
            rel = orange,
            cutoff = orange,
            cusum = purple

            abs.(rel+cutoff+cusum) = red
            cusum.(cutoff+rel) = red
            */
            if ((hasCuSum && (hasCutoff || hasRel)) || (hasAbs && (hasRel || hasCutoff | hasCuSum)))
                return "threshold-mixed-algorithm";
            if (hasCuSum)
                return "threshold-advanced-algorithm";
            if (hasCutoff || hasRel)
                return "threshold-math-algorithm";
            return "threshold-simple-algorithm";
        }
    }
}