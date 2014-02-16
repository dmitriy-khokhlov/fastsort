using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastSort
{
    class CharNode
    {
        private SortedDictionary<char, CharNode> _children = new SortedDictionary<char, CharNode>(new Comparer<char>());

        private bool _isFullWord = false;

        public CharNode GetChild(char childChar)
        {
            CharNode child;
            if (!_children.TryGetValue(childChar, out child))
            {
                child = new CharNode();
                _children.Add(childChar, child);
            }
            return child;
        }

        public void MarkAsFullWord()
        {
            _isFullWord = true;
        }

        public void FillSortedWordsList(string wordPrefix, List<string> wordList)
        {
            if (_isFullWord)
            {
                wordList.Add(wordPrefix);
            }

            foreach (KeyValuePair<char, CharNode> childKeyValuePair in _children)
            {
                childKeyValuePair.Value.FillSortedWordsList(wordPrefix + childKeyValuePair.Key, wordList);
            }
        }
    }
}
