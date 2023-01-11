namespace C2M2H1_TemplateMethod.TemplateMethod_Pratice
{
    public class SearchLongestMessage {
        public string search(string[] messages) {
            var maxLengthMessage = "";
            foreach (var message in messages)
            {
                if (message.Length > maxLengthMessage.Length) {
                    maxLengthMessage = message;
                }
                Console.WriteLine(message);
                
            }
            return maxLengthMessage;
        }
    }
    public class SearchEmptyMessageIndex {
        public int search(String[] messages) {
            var index = 0;
            while (index < messages.Length && !string.IsNullOrEmpty( messages[index])) {
                Console.WriteLine(messages[index]);
                index ++;
            }
            return index >= messages.Length ? -1 : index;
        }
    } 
    
    public class CountNumberOfWaterballs {
        public int count(string[] messages) {
            var count = 0;
            foreach (var message in messages)
            {
                if ("Waterball".Equals(message)) {
                    count ++;
                }
                Console.WriteLine(message);
                
            }
            return count;
        }
    }
    
}