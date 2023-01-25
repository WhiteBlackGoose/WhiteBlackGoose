module www.gpg.index

open Giraffe.ViewEngine
open Page

let html = PageWrap.wrap www.``static``.styles.css {
    title = "My GPG key"
    url = "gpg"
    filename = "index.html"
    contents = [
        h2 [] [ anc "fingerprint"; Text "Fingerprint" ]
        p [] [ Text "Key ID: goose-new &lt;wbg at angouri.org&gt; (replace at with @)" ]
        p [] [ Text "Value: 640BEDDE9734310ABFA3B25752EDAE6A3995AFAB" ]
        p [] [ Text $"""Key server: {_a "https://keys.openpgp.org/search?q=640BEDDE9734310ABFA3B25752EDAE6A3995AFAB" "keys.openpgp.org" } """ ]

        h2 [] [ anc "key"; Text "Key" ]
        p [] [
            pre [] [ code [] [
            Text """
            -----BEGIN PGP PUBLIC KEY BLOCK-----

            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
            Bw==
            =hY1T
            -----END PGP PUBLIC KEY BLOCK-----
        """
        ]]
        ]
    ]
}
