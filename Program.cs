using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace StationCommander {
  class BattlePlan {
    public Dictionary<string, Plan> plans {get; set;}
    public Dictionary<string, Policy> policies {get; set;}
  }
  class Plan {
    public string artifact {get; set;}
    public string directory {get; set;}
    public string policy {get; set;}
  }
  class Policy {
    public string method {get; set;}
    public string output {get; set;}
  }
  class Program {
    private const string DEP_EXT_ = ".READY";
    private const string CONFIG_ = "battleplan.json";
    static void Main(string[] args) {
      string json_text = File.ReadAllText(CONFIG_);
      BattlePlan bp = JsonSerializer.Deserialize<BattlePlan>(json_text);
      foreach(KeyValuePair<string, Plan> kv in bp.plans) {
        Plan plan = kv.Value;
        if(!bp.policies.ContainsKey(plan.policy)) {
          throw new JsonException("Policy missing in config");
        }
        Policy policy = bp.policies[plan.policy];
        string artifact = plan.artifact;
        string directory = plan.directory;
        if (File.Exists(directory + artifact + DEP_EXT_)) {
          switch (policy.method.ToUpper()) {
            case "FOLDER": {
              Folder f = new Folder(artifact, policy.output);
              f.Deploy(true);
              break;
            }
          }
        }
      }
    }
  }
}
