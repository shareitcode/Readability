using System.Collections.Generic;

namespace Readability
{
    internal static class Constants
    {
        internal readonly static short FLAG_STRIP_UNLIKELYS = 0x1;
        internal readonly static short FLAG_WEIGHT_CLASSES = 0x2;
        internal readonly static short FLAG_CLEAN_CONDITIONALLY = 0x4;

        // https://developer.mozilla.org/en-US/docs/Web/API/Node/nodeType
        internal readonly static short ELEMENT_NODE = 1;
        internal readonly static short TEXT_NODE = 3;

        // Max number of nodes supported by this parser. Default: 0 (no limit)
        internal readonly static short DEFAULT_MAX_ELEMS_TO_PARSE = 0;

        // The number of top candidates to consider when analysing how
        // tight the competition is among candidates.
        internal readonly static short DEFAULT_N_TOP_CANDIDATES = 5;

        // Element tags to score by default.
        internal readonly static string[] DEFAULT_TAGS_TO_SCORE = new string[] { "section", "h2", "h3", "h4", "h5", "h6", "p", "td", "pre" };

        // The default number of chars an article must have in order to return a result
        internal readonly static short DEFAULT_CHAR_THRESHOLD = 500;

        internal readonly static string[] UNLIKELY_ROLES = new string[] { "menu", "menubar", "complementary", "navigation", "alert", "alertdialog", "dialog" };

        internal readonly static string[] DIV_TO_P_ELEMS = new string[] { "BLOCKQUOTE", "DL", "DIV", "IMG", "OL", "P", "PRE", "TABLE", "UL" };

        internal readonly static string[] ALTER_TO_DIV_EXCEPTIONS = new string[] { "DIV", "ARTICLE", "SECTION", "P" };

        internal readonly static string[] PRESENTATIONAL_ATTRIBUTES = new string[]
        {
            "align", "background", "bgcolor", "border", "cellpadding", "cellspacing", "frame", "hspace", "rules", "style", "valign", "vspace"
        };

        internal readonly static string[] DEPRECATED_SIZE_ATTRIBUTE_ELEMS = new string[] { "TABLE", "TH", "TD", "HR", "PRE" };

        // The commented out elements qualify as phrasing content but tend to be
        // removed by readability when put into paragraphs, so we ignore them here.
        internal readonly static string[] PHRASING_ELEMS = new string[]
        {
            // "CANVAS", "IFRAME", "SVG", "VIDEO",
            "ABBR", "AUDIO", "B", "BDO", "BR", "BUTTON", "CITE", "CODE", "DATA",
            "DATALIST", "DFN", "EM", "EMBED", "I", "IMG", "INPUT", "KBD", "LABEL",
            "MARK", "MATH", "METER", "NOSCRIPT", "OBJECT", "OUTPUT", "PROGRESS", "Q",
            "RUBY", "SAMP", "SCRIPT", "SELECT", "SMALL", "SPAN", "STRONG", "SUB",
            "SUP", "TEXTAREA", "TIME", "VAR", "WBR"
        };

        // These are the classes that readability sets itself.
        internal readonly static string[] CLASSES_TO_PRESERVE = new string[] { "page" };

        // These are the list of HTML entities that need to be escaped.
        internal readonly static Dictionary<string, string> HTML_ESCAPE_MAP = new Dictionary<string, string>()
        {
            { "lt", "<" }, {"gt", ">" }, {"amp", "&"}, {"quot", "\""}, {"apos", "'"}, {"apos", "'"}
        };

        // All of the regular expressions in use within readability.
        // Defined up here so we don't instantiate them repeatedly in loops.
        internal static class REGEXPS
        {
            // NOTE: These two regular expressions are duplicated in
            // Readability-readerable.js. Please keep both copies in sync.
            internal readonly static string unlikelyCandidates = "/-ad-|ai2html|banner|breadcrumbs|combx|comment|community|cover-wrap|disqus|extra|footer|gdpr|header|legends|menu|related|remark|replies|rss|shoutbox|sidebar|skyscraper|social|sponsor|supplemental|ad-break|agegate|pagination|pager|popup|yom-remote/i";
            internal readonly static string okMaybeItsACandidate = "/and|article|body|column|content|main|shadow/i";
            internal readonly static string positive = "/article|body|content|entry|hentry|h-entry|main|page|pagination|post|text|blog|story/i";
            internal readonly static string negative = "/-ad-|hidden|^hid$| hid$| hid |^hid |banner|combx|comment|com-|contact|foot|footer|footnote|gdpr|masthead|media|meta|outbrain|promo|related|scroll|share|shoutbox|sidebar|skyscraper|sponsor|shopping|tags|tool|widget/i";
            internal readonly static string extraneous = "/print|archive|comment|discuss|e[\\-]? mail|share|reply|all|login|sign|single|utility/i";
            internal readonly static string byline = "/byline|author|dateline|writtenby|p-author/i";
            internal readonly static string replaceFonts = "/<(\\/?)font[^>]*>/gi";
            internal readonly static string normalize = "/\\s{2,}/g";
            internal readonly static string videos = "/\\/\\/(www\\.)? ((dailymotion|youtube|youtube-nocookie|player\\.vimeo|v\\.qq)\\.com|(archive|upload\\.wikimedia)\\.org|player\\.twitch\\.tv)/i";
            internal readonly static string shareElements = "/(\b|_)(share|sharedaddy)(\b|_)/i";
            internal readonly static string nextLink = "/(next|weiter|continue|>([^\\|]|$)|»([^\\|]|$))/i";
            internal readonly static string prevLink = "/(prev|earl|old|new|<|«)/i";
            internal readonly static string tokenize = "/\\W+/g";
            internal readonly static string whitespace = "/^\\s*$/";
            internal readonly static string hasContent = "/\\S$/";
            internal readonly static string hashUrl = "/^#.+/";
            internal readonly static string srcsetUrl = "/(\\S+)(\\s+[\\d.]+[xw])? (\\s* (?:,|$))/g";
            internal readonly static string b64DataUrl = "/^data:\\s* ([^\\s;,]+)\\s*;\\s* base64\\s*,/i";
            internal readonly static string jsonLdArticleTypes = "/^Article|AdvertiserContentArticle|NewsArticle|AnalysisNewsArticle|AskPublicNewsArticle|BackgroundNewsArticle|OpinionNewsArticle|ReportageNewsArticle|ReviewNewsArticle|Report|SatiricalArticle|ScholarlyArticle|MedicalScholarlyArticle|SocialMediaPosting|BlogPosting|LiveBlogPosting|DiscussionForumPosting|TechArticle|APIReference$/";
        }
    }
}