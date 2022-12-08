namespace Persistence
{
    public class TagsGenerator
    {
        // IDEA: we can add more tags by filtering inside the tag, by using groups -- too difficult to add right now
        private static readonly string[] Tags = { // use blank spaces for later or else there will be issues
            // General
            "GENERAL", "MEDICAL", "SCIENCE", "TECHNOLOGY", "ENGINEERING", "MATH", "ART", "GAMING", "EDUCATION", "ECONOMIC", // 10
            // Key Locations
            "GREAT LAKES", "SAHARA DESERT", "SIBERIA", "ARTIC", "ANTARTIC", // 5
            // Majors
            "GERMANY", "THE BRITISH ISLES", "UNITED STATE OF AMERICA", "JAPAN", "RUSSIA/USSR", "CHINA", "FRANCE", "SPAIN", "PORTUGAL", "ITALY", // 10
            // War
            "LAST STAND", "RESCUE", "AWARD", "KEY BATTLE", "INVASION", "PEACE", "OFFENSIVE", // 7
            // Effect
            "INTERNATIONAL", "NATIONAL", "REGIONAL", // 3
            // World War
            "WWI", "WWII", "INTERWAR", "POSTWAR", "PREWAR", "PACIFIC", "ATLANTIC", // 7
            // Continent
            "NORTH AMERICA", "SOUTH AMERICA", "EUROPE", "ASIA", "OCEANIA", "AFRICA", // 6
            // Extra
            "CRIME", "HEROIC ACTION", "HOLIDAY", "NAVY/MARINE/COAST GUARD", "ARMY/AIRFORCE", "TEST/DO NOT DISPLAY" // 6
        };

        private static readonly string[] HIDDEN = {"TEST/DO NOT DISPLAY"};

        public static readonly ulong DONOTDISPLAY = 9223372036854775808; // yeah...

        public static string[] TagList() {
            return Tags;
        }

        public static ulong TestTags(int max_length) {
            bool isDebug = false;

            if (max_length < 0 || max_length >= 64) throw new Exception("The max number of tags requested is too high!");

            // test TagToKey
            string[] test_Tags = {};
            for (int i = 0; i < max_length; i++) {
                int index = Random.Shared.Next(0,max_length);
                if (!test_Tags.Contains(Tags[index])) {
                    test_Tags.Append(Tags[index]);
                }
            }

            ulong key = TagToKey(ref test_Tags);

            if (isDebug) {
                string[] keysReturn = KeyToTag(key);

                Console.WriteLine(test_Tags);
                Console.WriteLine(key);
                Console.WriteLine(keysReturn);
            }

            return key | DONOTDISPLAY;
        }

        public static ulong TagToKey(ref string[] tag_ref) {
            ulong value = 0;
            for (int i = 0; i < Tags.Length; i++) {
                if (tag_ref.Contains(Tags[i])) {
                    value |= (ulong)1 << i;
                }
            }
            return value;
        }

        public static string[] KeyToTag(ulong key) {
            string[] Tags_used = {};

            ulong temp_key = key;
            for (int i = 0; i < Tags.Length; i++) {
                if (temp_key % 2 == 1) {
                    Tags_used.Append(Tags[Tags.Length - i - 1]); // because it's backwords
                }
                temp_key >>= 1;
            }

            return Tags_used;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}