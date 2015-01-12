using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using edu.stanford.nlp.parser;
using java.util;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.util;
using System.Web;
using java.nio.file;
using edu.stanford.nlp.tagger.maxent;
using java.io;
using Psydpt.Business.Entities;


namespace Psydpt.Business.Services
{
    public class Tokenizer
    {
        public static string AppDataPath = HttpContext.Current.Server.MapPath("~/App_Data");
        public static string PosTaggerResPath = System.IO.Path.Combine(AppDataPath, "StandfordNlpTagger");
        public static string EntitiesPath = System.IO.Path.Combine(PosTaggerResPath, "Entities");

        public static string EngBidirDisTagger_EntityPath = System.IO.Path.Combine(EntitiesPath, "english-bidirectional-distsim.tagger");
        //public static CRFClassifier Classifier = CRFClassifier.getClassifierNoExceptions(NlpEntityPath);

        //@"..\..\..\..\temp\stanford-postagger-2013-06-20\models\wsj-0-18-bidirectional-nodistsim.tagger";

        public static Dictionary<string, List<Entities.Tag>> TagParaghraph(string content)
        {
            var result = new Dictionary<string, List<Entities.Tag>>();

            using (java.io.StringReader jstrReader = new java.io.StringReader(content))
            {
                var tagger = new MaxentTagger(EngBidirDisTagger_EntityPath);
                foreach (List sentence in MaxentTagger.tokenizeText(jstrReader).toArray())
                {
                    var tSentence = tagger.tagSentence(sentence);
                   // result.Add(edu.stanford.nlp.ling.Sentence.listToString(tSentence, false));
                }         
            }

            return result;
        }
          
        


    }
}
