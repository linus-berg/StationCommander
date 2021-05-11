using System;
using System.IO;
using System.IO.Compression;

namespace StationCommander {
  public class Folder {
    private readonly string artifact_;
    private readonly string out_dir_;
    public Folder(string artifact, string out_dir) {
      this.artifact_ = artifact;
      this.out_dir_ = out_dir;
    }

    public bool Deploy(bool clear = false) {
      /* Clear previous */
      if (clear) {
        Directory.Delete(out_dir_, true);
      }
      if (!Directory.Exists(out_dir_)) {
        Directory.CreateDirectory(out_dir_);
      }
      if (File.Exists(artifact_)) {
        ZipFile.ExtractToDirectory(artifact_, out_dir_, true);
      } else {
        throw new FileNotFoundException("Zip not found.");
      }
      return true;
    }
  }
}