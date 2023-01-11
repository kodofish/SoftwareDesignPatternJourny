namespace C2M2H1_TemplateMethod.TemplateMethod_Pratice
{
    public abstract class TemplateClass<T>
    {
        protected T tempData = default(T);
        protected T Search(string[] messages)
        {
            foreach (var message in messages)
            {
                SearchLogic<T>(message);
            }

            return SearchResult();
        }
        protected abstract T SearchResult();

        protected abstract void SearchLogic<T>(string message);
        
        protected static void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class SearchLongestMessage : TemplateClass<string>
    {
        protected override string SearchResult()
        {
            return tempData;
        }
        protected override void SearchLogic<T>(string message)
        {
            if (message.Length > tempData.Length)
                tempData = message;
            
            OutputMessage(message);
        }
    }
    public class SearchEmptyMessageIndex : TemplateClass<int>
    {
        private int emptyIndex = -1;
        
        protected override int SearchResult()
        {
            return emptyIndex;
        }
        protected override void SearchLogic<T>(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                if (emptyIndex == -1)
                    emptyIndex = tempData;
            }
            else
                OutputMessage(message);

            tempData++;
        }
    } 
    
    public class CountNumberOfWaterballs : TemplateClass<int>
    {
        protected override int SearchResult()
        {
            return tempData;
        }
        protected override void SearchLogic<T>(string message)
        {
            if ("Waterball".Equals(message)) {
                tempData ++;
            }
            OutputMessage(message);
        }
    }
}