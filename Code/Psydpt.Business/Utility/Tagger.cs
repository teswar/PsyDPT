using edu.stanford.nlp.tagger.maxent;
using java.util;
using Psydpt.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Psydpt.Business.Utility
{
    public class Tagger
    {
        public static string AppDataPath = HttpContext.Current.Server.MapPath("~/App_Data");
        public static string PosTaggerResPath = System.IO.Path.Combine(AppDataPath, "StandfordNlpTagger");
        public static string EntitiesPath = System.IO.Path.Combine(PosTaggerResPath, "Entities");

        public static string EngBidirDisTagger_EntityPath = System.IO.Path.Combine(EntitiesPath, "english-bidirectional-distsim.tagger");


        public const string WORD_TAG_SPLITTER = "/";
        public const string TAGGED_WORD_PAIR_SPLITTER = " ";
        //public static CRFClassifier Classifier = CRFClassifier.getClassifierNoExceptions(NlpEntityPath);

        //@"..\..\..\..\temp\stanford-postagger-2013-06-20\models\wsj-0-18-bidirectional-nodistsim.tagger";

        public static TaggedPara TagParaghraph(string content, List<string> tagsToInclude = null)
        {
            TaggedPara result = new TaggedPara();

            using (java.io.StringReader jstrReader = new java.io.StringReader(content))
            {
                var tagger = new MaxentTagger(EngBidirDisTagger_EntityPath);
                var lastWordIndex = 0;

                foreach (List sentence in MaxentTagger.tokenizeText(jstrReader).toArray())
                {
                    if (sentence.size() <= 0) { continue; }
 
                    var taggedSentenceList = tagger.tagSentence(sentence);
                    var tSentence = edu.stanford.nlp.ling.Sentence.listToString(sentence);
                    var ttSentence =  edu.stanford.nlp.ling.Sentence.listToString(taggedSentenceList, false, WORD_TAG_SPLITTER);
                    
                    lastWordIndex = content.IndexOf(sentence.get(0).ToString(), lastWordIndex);
                    result.Add(new Entities.TaggedSentence(lastWordIndex, tSentence, ttSentence));
                    lastWordIndex = content.LastIndexOf(sentence.get(0).ToString(), lastWordIndex) + sentence.get(0).ToString().Length;
                }
            }

            return result;
        }
    }
}
