using Psydpt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Psydpt.Business.Entities
{

    public class Tag
    {
        public string Puntuation {get; set;}
        public string Phrase {get; set;}
        public int  Index {get; set;}
    }

    public class TaggedPara : List<TaggedSentence> 
    {
        public TaggedPara()
            :base()
        {}

         public TaggedPara(IEnumerable<TaggedSentence> sentences)
            :base(sentences)
        {}

         public IEnumerable<Tag> Tags()
         {
             var result = new List<Tag>();

             foreach (var sentence in this)
             {
                 foreach (var tags in sentence.Tags.Values)
                 {
                     result.AddRange(tags.Select(m => m));
                 }
             }

             return result;
         }


         public void RemoveTags(List<string> tags, bool exclude = false)
         {
             foreach (var sentence in this)
             {
                 foreach (var tgs in sentence.Tags.Values)
                 {
                     if (exclude) { tgs.RemoveAll(m => !tags.Any(rt => rt.Equals(m.Puntuation))); }
                     else { tgs.RemoveAll(m => tags.Any(rt => rt.Equals(m.Puntuation))); }
                 }
             }
         }

    }


    public class TaggedSentence
    {
        public const string WORD_TAG_SPLITTER = "/";
        public const string TAGGED_WORD_PAIR_SPLITTER = " ";

        public int Index { get; set; }
        public string Sentence { get; set; }
        public Dictionary<string, List<Tag>> Tags { get; set; }



        public TaggedSentence()
        {
            Tags = new Dictionary<string, List<Tag>>();
        }

        public TaggedSentence(int index, string sentence, string taggedSentence)
            : this()
        {

            Index = index;
            Sentence = sentence;

            var lastWordIndex = 0;

            foreach (string taggedWord in taggedSentence.Split(TAGGED_WORD_PAIR_SPLITTER.ToCharArray()))
            {
                var items = taggedWord.Split(WORD_TAG_SPLITTER.ToCharArray());
                if (items == null || items.Length < 2) { continue; }


                var tempTag = new Entities.Tag();
                tempTag.Phrase = items[0];
                tempTag.Puntuation = items[1];
                tempTag.Index = Sentence.IndexOf(tempTag.Phrase, lastWordIndex);
                if (tempTag.Index >= 0) { lastWordIndex += tempTag.Phrase.Length; }

                List<Entities.Tag> tags = null;
                if (!Tags.ContainsKey(tempTag.Puntuation)) { Tags.Add(tempTag.Puntuation, new List<Entities.Tag>()); }

                tags = Tags[tempTag.Puntuation];
                tags.Add(tempTag);
            }

        }



    }

    public class PerdictionMatch
    {
        public Disorder Disorder;
        public List<string> Matches;


        public PerdictionMatch()
        {
            Disorder = null;
            Matches = new List<string>();
        }

        public static PerdictionMatch Evaluate(TaggedPara taggedPara, Disorder disorder)
        {
            PerdictionMatch result = new PerdictionMatch() { Disorder = disorder };
            var pattern = string.Format("({0})", string.Join("|", disorder.KeywordCollection));
            pattern = Regex.Replace(pattern, "\\s+", "|", RegexOptions.Multiline);
            var input = string.Join(", ", taggedPara.Tags().Select(m => m.Phrase));
            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            if (matches != null) 
            {
                foreach(Match mat in matches)
                {
                    result.Matches.Add(mat.Value);
                }
            }

            return result;
        }
    }
    
}
