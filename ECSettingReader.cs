using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileCopy
{
    class ECSettingReader
    {
        private const string SETTING_FILE_NAME = "ECSetting.json";
        public void Read(string path)
        {
            try
            {

                var ret = JsonConvert.DeserializeObject<PostRoot>(File.ReadAllText(Path.Combine(path + SETTING_FILE_NAME)));

                //foreach (var f in ret.Posts)
                //{
                //    pci.MessageBox(1, f.Value.Path);
                //}
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }

    public class Post
    {
        public string ID { set; get; }
        public string Path { set; get; }
    }

    public class PostRoot
    {
        public Dictionary<string, Post> Posts { get; set; }
    }

}
