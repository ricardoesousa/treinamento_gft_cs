using System.Collections.Generic;

namespace API_Rest.HATEOAS
{
    public class HATEOAS
    {
        private string url;
        private string protocol = "https://";
        public List<Link> actions = new List<Link>();

        public HATEOAS(string url)
        {
            this.url = url;
        }

        public HATEOAS(string url, string protocol)
        {
            this.url = url;
            this.protocol = protocol;
        }

        public void AddAction(string rel, string method)
        {
            actions.Add(new Link(this.protocol + this.url, rel, method));
        }

        public Link[] GetActions(string sufix)
        {
            Link[] templinks = new Link[actions.Count];

            for(int i = 0; i < templinks.Length; i++)
            {
                templinks[i] = new Link(actions[i].href, actions[i].rel, actions[i].method);
            }

            foreach (var link in templinks)
            {
                link.href = link.href + "/" + sufix;
            }
            return templinks;
        }
    }
}