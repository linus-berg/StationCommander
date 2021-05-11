using System;

namespace StationCommander.Methods {
  class Service {
    private readonly string name_;
    private readonly string file_;
    private readonly string args_;
    public Service(string name, string file, string args) {
      this.name_ = name;
      this.file_ = file;
      this.args_ = args;
    }
  }
}