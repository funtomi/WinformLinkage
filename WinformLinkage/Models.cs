using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformLinkage {
    /// <summary>
    /// 数据获取类
    /// </summary>
    public class Models {
        public List<string> GetCircuits() {
            return new List<string> { 
            "回路1","回路2","回路3","回路4","回路5"
            };
        }
         
        internal string GetSchematicPath(string circuit) {
            return string.Format("测试PPT\\{0}.pptx",circuit);
        }

        internal List<string> GetPhenomenons(string circuit) {
            if (string.IsNullOrEmpty(circuit)) {
                return null;
            }
            switch (circuit) {
                default:
                case "回路1":
                    return new List<string>() {"现象11","现象12","现象13","现象14","现象15" };
                case "回路2":
                    return new List<string>() {"现象21","现象22","现象23","现象24","现象25" };
                case "回路3":
                    return new List<string>() {"现象31","现象32","现象33","现象34","现象35" };
                case "回路4":
                    return new List<string>() {"现象41","现象42","现象43","现象44","现象45" };
                case "回路5":
                    return new List<string>() {"现象51","现象52","现象53","现象54","现象55" };
            }
        }

        internal List<string> GetReasons(string p) {
            if (string.IsNullOrEmpty(p)) {
                return null;
            }
            var str1 = string.Format("原因{0}1",p);
            var str2 = string.Format("原因{0}2", p);
            var str3 = string.Format("原因{0}3", p);
            var str4 = string.Format("原因{0}4", p);
            var str5 = string.Format("原因{0}5", p);
            return new List<string>() { str1,str2,str3,str4,str5 };
 
        }

        internal List<string> GetPositions(string p) {
            if (string.IsNullOrEmpty(p)) {
                return null;
            }
            var str1 = string.Format("定位{0}1", p);
            var str2 = string.Format("定位{0}2", p);
            var str3 = string.Format("定位{0}3", p);
            var str4 = string.Format("定位{0}4", p);
            var str5 = string.Format("定位{0}5", p);
            return new List<string>() { str1, str2, str3, str4, str5 };
        }
    }
}
