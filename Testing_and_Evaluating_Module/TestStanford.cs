﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.pipeline;
using java.util;
using System.IO;
using Console = System.Console;

namespace Testing_and_Evaluating_Module
{
    class TestStanford
    {
      //static void Main(string[] args)
      //  {
      //      // Path to the folder with models extracted from `stanford-corenlp-3.7-models.jar`
      //      var jarRoot = @"stanford-corenlp-3.7-models\";


      //      const string text = "I went or a run. Then I went to work. I had a good lunch meeting with a friend name John Jr. The commute home was pretty good.";

      //      // Annotation pipeline configuration
      //      var props = new Properties();
      //      props.setProperty("annotators", "tokenize, ssplit, pos, lemma, ner, parse, dcoref");
      //      props.setProperty("sutime.binders", "0");

      //      // We should change current directory, so StanfordCoreNLP could find all the model files automatically 
      //      var curDir = Environment.CurrentDirectory;
      //      Directory.SetCurrentDirectory(jarRoot);
      //      var pipeline = new StanfordCoreNLP(props);
      //      Directory.SetCurrentDirectory(curDir);

      //      // Annotation
      //      var annotation = new Annotation(text);
      //      pipeline.annotate(annotation);

      //      // these are all the sentences in this document
      //      // a CoreMap is essentially a Map that uses class objects as keys and has values with custom types
      //      var sentences = annotation.get(typeof(CoreAnnotations.SentencesAnnotation));
      //      if (sentences == null)
      //      {
      //          return;
      //      }
      //      foreach (Annotation sentence in sentences as ArrayList)
      //      {
      //          Console.WriteLine(sentence);
      //      }
      //  }
        
       
    }
}
