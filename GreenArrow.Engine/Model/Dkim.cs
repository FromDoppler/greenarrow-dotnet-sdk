namespace GreenArrow.Engine.Model
{
    /// <summary>
    /// Dkim to use in X-GreenArrow-DKIM Header
    /// </summary>
    public class Dkim
    {
        /// <summary>
        /// The fully qualified domain name of the DKIM key to sign with. 
        /// This is used in the d= value of the signature, and (in the absence of use_key_from) it is be used to find the private key for creating the signature.
        /// </summary>
        public string Domain { get; init; }

        /// <summary>
        /// If a true value (for example, JSON true or a number greater than or equal to one), then:
        /// <list type="bullet">
        /// <item>If a Sender header is not present, the From header’s domain is used as if it was specified as a domain parameter.</item>
        /// <item>If a Sender header is present, the Sender header’s domain is used as if it was specified as a domain parameter.</item>
        /// </list>
        /// </summary>
        public bool? FromDomain { get; init; }

        /// <summary>
        /// The selector of the DKIM key to sign with.
        /// This is used in the s = value of the signature, and(in the absence of use_key_from) it is used to find the private key for creating the signature.
        /// If not set: If there is a default DKIM key for the specified domain name, it is used.
        /// If no default key is found, an error is logged and no signature added.
        /// </summary>
        public string Selector { get; init; }

        /// <summary>
        /// Defines where to get the private key for creating the signature.
        /// This is intended to be used when multiple domains all use the same private key.The private key can be loaded into GreenArrow once and then used for signing for various domains.
        /// If use_key_from is specified then it overrides how to get the private key for creating the signature.The domain and selector parameters still specify the domain and selector used in the DKIM signature(d= and s= values).
        /// use_key_from must be the domain name, optionally followed by a slash and a selector name.
        /// <list type="bullet">
        /// <listheader>For example:</listheader>
        /// <item>example.com – use the default key for example.com.If there is no default key, then an error is logged.</item>
        /// <item>example.com/foo – use the key for the domain example.com with the selector foo.If no such key is found, then an error is logged.</item>
        /// </list>
        /// When using use_key_from, the selector parameter must be specified. 
        /// </summary>
        public string UseKeyFrom { get; init; }

        /// <summary>
        /// By default, if the same DKIM key is specified more than once, only the first instance is honored.
        /// The others are suppressed to avoid duplicate signatures.
        /// Setting allow_duplicate to a true value(for example, JSON true or a number greater than or equal to one) disables this suppression.
        /// </summary>
        public bool? AllowDuplicate { get; init; }
    }
}
