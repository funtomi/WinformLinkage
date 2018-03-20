using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WinformLinkage {
    /// <summary>
    /// 数据类
    /// </summary>
    public class Models {
        private static string PATH = ConfigurationManager.AppSettings["path"].ToString();
        private static string DEFAULT_FILE = ConfigurationManager.AppSettings["defaltFile"].ToString();
        private List<Circuit> _circuits = new List<Circuit>();
        private string _fileName = "";
        private string _filePath = "";

        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool HasData {
            get { return _hasData; }
            set { _hasData = value; }
        }
        private bool _hasData = true;
        public Models() {
            Initial();
        }
        public Models(string filePath) {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath) || Path.GetExtension(filePath) != ".json") {
                _hasData = false;
                return;
            }
            _filePath = Path.GetDirectoryName(filePath) + "\\";
            _fileName = Path.GetFileName(filePath);
            Initial();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void Initial() {
            var json = JsonHelper.GetFileJson(_filePath + _fileName);
            if (string.IsNullOrEmpty(json)) {
                _hasData = false;
                return;
            }
            _circuits = JsonHelper.ParseFromJson<Circuits>(json).Rows;
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        private void ClearModel() {
            this._hasData = false;
            this._circuits = null;
            this._fileName = DEFAULT_FILE;
        }

        /// <summary>
        /// 获取回路集合
        /// </summary>
        /// <returns></returns>
        public List<string> GetCircuits() {
            if (_circuits == null || _circuits.Count == 0) {
                return null;
            }
            List<string> list = new List<string>();
            foreach (var item in _circuits) {
                list.Add(item.Name);
            }
            return list;
        }

        /// <summary>
        /// 获取原理图路径
        /// </summary>
        /// <param name="circuit"></param>
        /// <returns></returns>
        internal string GetSchematicPath(string circuit) {
            if (_circuits == null || _circuits.Count == 0) {
                return null;
            }
            var currentCircuit = _circuits.First<Circuit>(l => l.Name == circuit);
            if (File.Exists(currentCircuit.Schematic)) {
                return currentCircuit.Schematic;
            }
            return _filePath + currentCircuit.Schematic;
        }

        /// <summary>
        /// 获取错误现象集合
        /// </summary>
        /// <param name="circuit"></param>
        /// <returns></returns>
        internal List<string> GetPhenomenons(string circuit) {
            if (string.IsNullOrEmpty(circuit)) {
                return null;
            }
            var currentCircuit = this._circuits.FirstOrDefault<Circuit>(l => l.Name == circuit);
            if (currentCircuit.FaliurePhenomenon == null || currentCircuit.FaliurePhenomenon.Count == 0) {
                return null;
            }
            var list = currentCircuit.FaliurePhenomenon.Select(l => l.Name).ToList<string>();
            return list;
        }

        /// <summary>
        /// 获取故障原因列表
        /// </summary>
        /// <param name="circuit">回路</param>
        /// <param name="phenomenon">故障现象</param>
        /// <returns></returns>
        internal List<string> GetReasons(string circuit, string phenomenon) {
            if (string.IsNullOrEmpty(phenomenon) || string.IsNullOrEmpty(circuit)) {
                return null;
            }
            var currentCircuit = this._circuits.FirstOrDefault<Circuit>(l => l.Name == circuit);
            var currentPhenomenon = currentCircuit.FaliurePhenomenon.FirstOrDefault<FaliurePhenomenon>(l => l.Name == phenomenon);
            if (currentPhenomenon.Reason == null || currentPhenomenon.Reason.Count == 0) {
                return null;
            }
            var list = currentPhenomenon.Reason.Select(l => l.Name).ToList<string>();
            return list;
        }

        /// <summary>
        /// 获取故障定位列表
        /// </summary>
        /// <param name="c">回路</param>
        /// <param name="ph">故障现象</param>
        /// <param name="p">故障原因</param>
        /// <returns></returns>
        internal List<string> GetPositions(string c, string ph, string p) {
            if (string.IsNullOrEmpty(p) || string.IsNullOrEmpty(c) || string.IsNullOrEmpty(ph)) {
                return null;
            }
            var currentCircuit = this._circuits.FirstOrDefault<Circuit>(l => l.Name == c);
            var currentPhenomenon = currentCircuit.FaliurePhenomenon.FirstOrDefault<FaliurePhenomenon>(l => l.Name == ph);
            var currentReason = currentPhenomenon.Reason.FirstOrDefault<Reason>(l => l.Name == p);
            var list = currentReason.Value;
            return list;
        }

        /// <summary>
        /// 修改回路名称
        /// </summary>
        /// <param name="origin">原名</param>
        /// <param name="value">修改后的名称</param>
        internal void ChangeCircuit(string origin, string value) {
            if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(value)) {
                return;
            }
            var currentCircuit = this._circuits.FirstOrDefault<Circuit>(l => l.Name == origin);
            currentCircuit.Name = value;

        }

        /// <summary>
        /// 修改故障现象
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="value"></param>
        internal void ChangePhenomenon(string circuit, string origin, string value) {
            if (string.IsNullOrEmpty(circuit) || string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(value)) {
                return;
            }
            var currentCircuit = this._circuits.FirstOrDefault<Circuit>(l => l.Name == circuit);
            var currentPhenomenon = currentCircuit.FaliurePhenomenon.FirstOrDefault<FaliurePhenomenon>(l => l.Name == origin);
            currentPhenomenon.Name = value;
        }

        /// <summary>
        /// 修改故障原因
        /// </summary>
        /// <param name="p1">回路名称</param>
        /// <param name="p2">故障现象</param>
        /// <param name="origin"></param>
        /// <param name="value"></param>
        internal void ChangeReason(string p1, string p2, string origin, string value) {
            if (string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2) || string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(value)) {
                return;
            }
            var currentCircuit = this._circuits.FirstOrDefault<Circuit>(l => l.Name == p1);
            var currentPhenomenon = currentCircuit.FaliurePhenomenon.FirstOrDefault<FaliurePhenomenon>(l => l.Name == p2);
            var currentReason = currentPhenomenon.Reason.FirstOrDefault<Reason>(l => l.Name == origin);
            currentReason.Name = value;
        }

        /// <summary>
        /// 修改故障定位
        /// </summary>
        /// <param name="p1">回路名称</param>
        /// <param name="p2">故障现象</param>
        /// <param name="p3">故障原因</param>
        /// <param name="origin"></param>
        /// <param name="value"></param>
        internal void ChangePosition(string p1, string p2, string p3, string origin, string value) {
            if (string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2) || string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(value)) {
                return;
            }
            var currentCircuit = this._circuits.FirstOrDefault<Circuit>(l => l.Name == p1);
            var currentPhenomenon = currentCircuit.FaliurePhenomenon.FirstOrDefault<FaliurePhenomenon>(l => l.Name == p2);
            var currentReason = currentPhenomenon.Reason.FirstOrDefault<Reason>(l => l.Name == p3);
            var i = currentReason.Value.IndexOf(origin);
            currentReason.Value[i] = value;
        }

        internal void Save() {
            Save(this._filePath + _fileName);

        }

        /// <summary>
        /// 更改原理图保存路径
        /// </summary>
        /// <param name="p">回路</param>
        /// <param name="sSavePath"></param>
        internal void ChangeSchematicPath(string p, string sSavePath) {
            if (string.IsNullOrEmpty(p)) {
                return;
            }
            var currentCircuit = this._circuits.FirstOrDefault<Circuit>(l => l.Name == p);
            if (sSavePath.Contains(_filePath)) {
                currentCircuit.Schematic = sSavePath.Substring(_filePath.Length);
                return;
            }
            currentCircuit.Schematic = sSavePath;
        }

        internal void Save(string sSavePath) {
            var json = JsonHelper.Obj2Json(_circuits);
            var saveJson = "{\"Rows\":" + json + "}";
            JsonHelper.SaveFileJson(sSavePath, saveJson);
        }
    }

    [DataContract]
    internal class Circuits {
        [DataMember]
        public List<Circuit> Rows { get; set; } 
    }
    [DataContract]
    internal class Circuit {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Schematic { get; set; }
        [DataMember]
        public List<FaliurePhenomenon> FaliurePhenomenon { get; set; } 
    }
    [DataContract]
    internal class FaliurePhenomenon {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<Reason> Reason { get; set; } 
    }
    [DataContract]
    internal class Reason {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<string> Value { get; set; }
    }
}
