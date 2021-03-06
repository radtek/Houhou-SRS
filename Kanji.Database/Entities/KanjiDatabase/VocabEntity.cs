namespace Kanji.Database.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Kanji.Database.Helpers;
    
    public class VocabEntity : Entity
    {
        public VocabEntity()
        {
            this.Meanings = new HashSet<VocabMeaning>();
            this.Kanji = new HashSet<KanjiEntity>();
            this.Categories = new HashSet<VocabCategory>();
            this.SrsEntries = new HashSet<SrsEntry>();
            this.Variants = new HashSet<VocabEntity>();
        }
    
        public long ID { get; set; }
        public string KanjiWriting { get; set; }
        public string KanaWriting { get; set; }
        public bool IsCommon { get; set; }
        public Nullable<int> FrequencyRank { get; set; }
        public Nullable<int> JlptLevel { get; set; }
        public string Furigana { get; set; }
        public Nullable<int> WaniKaniLevel { get; set; }
        public Nullable<int> WikipediaRank { get; set; }
        public int GroupId { get; set; }
        public bool IsMain { get; set; }
    
        public ICollection<VocabMeaning> Meanings { get; set; }
        public ICollection<KanjiEntity> Kanji { get; set; }
        public ICollection<VocabCategory> Categories { get; set; }
        public ICollection<SrsEntry> SrsEntries { get; set; }
        public ICollection<VocabEntity> Variants { get; set; }

        public override string GetTableName()
        {
            return SqlHelper.Table_Vocab;
        }

        public override Dictionary<string, DbType> GetMapping()
        {
            return new Dictionary<string, DbType>()
            {
                { SqlHelper.Field_Vocab_IsCommon, DbType.Boolean },
                { SqlHelper.Field_Vocab_KanaWriting, DbType.String },
                { SqlHelper.Field_Vocab_KanjiWriting, DbType.String },
                { SqlHelper.Field_Vocab_FrequencyRank, DbType.Int32 },
                { SqlHelper.Field_Vocab_Furigana, DbType.String },
                { SqlHelper.Field_Vocab_JlptLevel, DbType.Int16 },
                { SqlHelper.Field_Vocab_WaniKaniLevel, DbType.Int32 },
                { SqlHelper.Field_Vocab_WikipediaRank, DbType.Int32 },
                { SqlHelper.Field_Vocab_GroupId, DbType.Int32 },
                { SqlHelper.Field_Vocab_IsMain, DbType.Boolean }
            };
        }

        public override object[] GetValues()
        {
            return new object[]
            {
                IsCommon, KanaWriting, KanjiWriting, FrequencyRank, Furigana, JlptLevel, WaniKaniLevel,
                WikipediaRank, GroupId, IsMain
            };
        }

        internal override Dao.DaoConnectionEnum GetEndpoint()
        {
            return Dao.DaoConnectionEnum.KanjiDatabase;
        }
    }
}
