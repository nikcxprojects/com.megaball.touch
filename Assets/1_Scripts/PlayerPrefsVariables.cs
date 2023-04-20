using System;

[Serializable]
public struct PlayerPrefsVariables
{
        public static string music = "Music";
        public static string sound = "Sound";
        public static string vibration = "Vibration";

        public static string GetByEnum(List list)
        {
                return list switch
                {
                        List.Music => music,
                        List.Sound => sound,
                        List.Vibration => vibration,
                        _ => throw new ArgumentOutOfRangeException(nameof(list), list, null)
                };
        }

        [Serializable]
        public enum List
        {
                Music,
                Sound,
                Vibration
        }
}
