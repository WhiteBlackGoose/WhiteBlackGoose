module www.donations.index

open Giraffe.ViewEngine
open Page

type Currency =
 | USD
 | EUR

type Donation = {
  name: string;
  url: string;
  amount: decimal;
  currency: Currency;
 }

let toUsd amount = function
 | USD -> amount
 | EUR -> amount * 1.06m

let setup =
 [
   { amount = 5.0m; currency = USD; name = "Kovid Goyal"; url = "https://www.patreon.com/kovidgoyal"  }
   { amount = 5.0m; currency = USD; name = "Jesse Duffield"; url = "https://github.com/jesseduffield"  }
   { amount = 7.0m; currency = EUR; name = "Dopomoga"; url = "https://www.patreon.com/dopomoga_am"  }
   { amount = 50.0m; currency = EUR; name = "voices UA"; url = "https://www.patreon.com/voices_org_ua" }
   { amount = 4.0m; currency = USD; name = "Tor Project"; url = "https://opencollective.com/thetorproject" }
   { amount = 2.0m; currency = USD; name = "Android Pass"; url = "https://opencollective.com/android-password-store" }
   { amount = 5.0m; currency = USD; name = "Veloren"; url = "https://opencollective.com/veloren" }
   { amount = 10.0m; currency = EUR; name = "Nix Community"; url = "https://opencollective.com/nix-community" }
   { amount = 1.0m; currency = USD; name = "shields.io"; url = "https://opencollective.com/shields" }
   { amount = 20.0m; currency = USD; name = "neovim"; url = "https://opencollective.com/neovim" }
   { amount = 20.0m; currency = EUR; name = "NixOS"; url = "https://opencollective.com/nixos" }
   { amount = 10.0m; currency = USD; name = "FSF"; url = "https://www.fsf.org/" }
   { amount = 5.7m; currency = EUR; name = "Mozilla"; url = "https://www.mozilla.org" }
   { amount = 10.0m; currency = EUR; name = "VoltEuropa"; url = "https://www.volteuropa.org/fundraising" }
   { amount = 20.0m; currency = EUR; name = "Children of Peace"; url = "https://www.childrenofpeace.org.uk/thanks-donor/" }
  ] |> List.sortBy (fun d -> -toUsd d.amount d.currency)

let toUsdFormat amount = function
 | USD -> td [] [ Text $"${amount} /mo" ]
 | EUR -> td [_title $"${toUsd amount EUR}"] [ Text $"{amount}€ /mo" ]

let sum =
 setup
 |> List.map (fun d -> toUsd d.amount d.currency)
 |> List.fold (+) 0.0m

let info = [
  p [] [ Text $"Total: ${sum}/mo" ]
  table [] [
   for { amount = amount; currency = currency; name = name; url = url } in setup do
    tr [] [
     td [] [ a [ _href url ] [ Text name ] ]
     toUsdFormat amount currency
    ]
  ]
 ]

let html = PageWrap.wrap www.``static``.styles.css {
 title = "List of donations"
 url = "donations"
 filename = "index.html"
 contents = [
  yield! info
 ]
}
