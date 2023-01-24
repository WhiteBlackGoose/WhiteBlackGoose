module www.blog.pass.index

open Giraffe.ViewEngine
open Page

let page = PageWrap.wrap www.``static``.styles.css {
    title = "Pass - password manager for geeks"
    depth = 2
    contents = [
        h2 [] [ anc "why"; Text "Why?" ]
        p [] [
            ul [] [
                li [] [ Text $"""✔️  CLI interface only, no need for GUI""" ]
                li [] [ Text $"""✔️  Works natively on Unix-like systems""" ]
                li [] [ Text $"""✔️  Has many clients for mainstream OS""" ]
                li [] [ Text $"""✔️  Only famous FOSS tools (used utils: {co "git"}, {co "pass"}, {co "gpg"}, {co "openssh"}, {co "passphrase2pgp"})""" ]
                li [] [ Text $"""✔️  No Google/Facebook account or other BS integration, your credentials are yours and stored by you on your computer""" ]
                li [] [ Text $"""✔️  Knowing your primary password is not enough to access your passwords""" ]
                li [] [ Text $"""✔️  Still can sync among devices""" ]
                li [] [ Text $"""✔️  You control where your backup stored (and it's encrypted too)""" ]
                li [] [ Text $"""X That's 100x more complicated to set up than most crappy password managers you'd find on the internet"""  ]
            ]
        ]

        h2 [] [ anc "intro"; Text "1. Intro to pass" ]
        p [] [
            Text $"""This {ur "https://www.passwordstore.org/" "tool"} provides an amazingly easy-to-use interface. Available for most major Unix-like operating systems (basically every desktop OS except Windows)."""
        ]
        p [] [
            Text "Install it how it's shown in the website."
        ]
        p [] [
            Text "Get started:"
            ul [] [
                li [] [ 
                    Text $"""{co "gpg --full-generate-key"} to generate key using GPG. In the end it will return something like {co "myname <mymail@quack.org>"}, remember this, it's your {it "Key ID"}. Let it be {co "user1"} for now (assuming you skipped mail). You will be asked to input a passphrase - that's what your private key will be decrypted with, make sure to remember it!""" ]
                li [] [ 
                    Text $"""{co "pass init user1"} inits your password store (input the key ID from the previous step).""" ]
                li [] [ 
                    Text $"""{co "pass insert website/username"} creates a prompt where you input your password.""" ]
                li [] [
                    Text $"""{co "pass website/username"} retrieves it. {co "pass -c website/username"} retrives it into clipboard.""" ]
            ]
        ]
        p [] [
            Text "Now, there are two approaches:"
            ul [] [
                li [] [ refanc "another-user" "Syncing with another user" ]
                li [] [ refanc "another-comp" "Syncing with another computer" ]
            ]
        ]

        h2 [] [ anc "another-user"; Text "2. How to sync your passwords with a new user?" ]
        h3 [] [ anc "git"; Text "2.1 Set up git" ]
        p [] [
            ol [] [
                li [] [ Text $"""Install {co "git"}""" ]
                li [] [ Text $"""Init repo: {co "pass git init"}""" ]
                li [] [ 
                    Text $"""If you want to use {co "github"} to sync:"""
                    ol [] [
                        li [] [ 
                            Text "I highly recommend using an SSH key as access token"
                            ol [] [
                                li [] [ Text $"""Set your username: {co "git --global user.name User1"}""" ]
                                li [] [ Text $"""Set your email: {co "git --global user.email user@quack.org"}""" ]
                                li [] [ Text $"""Generate an SSH keypair with ssh-keygen""" ]
                                li [] [ Text $"""Copy the content of the public key (e. g. {co "cat ~/.ssh/id_rsa.pub | xclip -sel clip"})""" ]
                                li [] [ Text $"""Go to github.com -> settings -> SSH keys -> new SSH key, copy the key into the text area and save""" ]
                            ]
                        ]
                        li [] [ Text $"""Create an empty repo""" ]
                        li [] [ Text $"""Locally do {co "pass git remote add github git@github.com:user1/myrepo.git"} (you don't have to name it {co "github"}, of course)""" ]
                        li [] [ Text $"""{co "pass git push github master"}""" ]
                    ]
                ]
                li [] [ 
                    Text $"""If you want to use your local server to sync:""" 
                    ol [] [
                        li [] [ Text $"""Assuming you access it over ssh""" ]
                        li [] [ Text $"""Create a repo on your remote server this way: {co "git init --bare pass-repo"}""" ]
                        li [] [ Text $"""Locally do {co "pass git remote add home ssh://user1@your-ip:your-ssh-port/path/to/pass-repo"}""" ]
                        li [] [ Text $"""{co "pass git push home master"}""" ]
                    ]
                ]
            ]
        ]
        p [] [ Text $"""I personally use both. Your passwords can only decrypted using your private keys that {bo "you never send"} to anyone. We can sync your passwords without them. As for now, we set up git, let's proceed by adding another device.""" ]

        h3 [] [ anc "add-comp"; Text "2.2 Add new computer" ]
        p [] [ Text $"""Let your current computer be {co "A"} and the new one is {co "B"}.""" ]
        p [] [
            ol [] [
                li [] [ 
                    Text $"""Key setup""" 
                    ol [] [
                        li [] [ Text $"""Generate a new GPG key on computer {co "B"} with a {bo "different"} key ID ({co "gpg --full-generate-key"})""" ]
                        li [] [ Text $"""Export {bo "public"} key, e. g. {co "gpg --export \"user2\" > pub.k"} and copy {co "user2.pub"} to computer {co "A"}""" ]
                        li [] [ Text $"""Export {bo "public"} key of computer {bo "A"} to computer {co "B"} (like step 2-3, but the other way around)""" ]
                        li [] [ Text $"""On computer {co "A"}, import this key: {co "gpg --import user2.pub"}""" ]
                    ]
                ]
                li [] [ Text $"""Reencrypt everthing on computer {co "A"}: {co "pass init \"user1\" \"user2\""}""" ]
                li [] [ 
                    Text "Push" 
                    ol [] [
                        li [] [ Text$"""If you sync with github: {co "pass git push github master"}""" ]
                        li [] [ Text$"""If you sync with your local computer: {co "pass git push home master"}""" ]
                    ]
                ]
                li [] [ Text $"""Init the password store and git repo on computer {co "B"} ({co "pass init \"user1\" \"user2\" && pass git init"})""" ]
                li [] [ 
                    Text $"""Add remote (same as in {bo "2.1"})""" 
                    ol [] [
                        li [] [ Text $"""For github: {co "pass git remote add github https://github.com/user1/myrepo"}""" ]
                        li [] [ Text $"""For local computer: `pass git remote add home ssh://user1@your-ip:your-ssh-port/path/to/pass-repo""" ]
                    ]
                ]
                li [] [ Text $"""Reset to it ({co "pass git reset --hard github/master"} for github and {co "pass git reset --hard home/master"} for home server)""" ]
            ]
        ]
        p [] [ Text $"""Done. You can now retrieve passwords and sync them between two computers, see how simple & user-friendly it all is?""" ]

        h2 [] [ anc "another-comp"; Text $"""2. How to sync your passwords with your other computer?""" ]
        p [] [ Text $"""Sending private keys is a security thread. That is why the recommended approach is always to generate a new keypair on a new device and add its public key to the list of "trusted" keys.""" ]
        p [] [ Text $"""However, it is of course inconvenient. It is also not very reliable, because you will lose all your encrypted data.""" ]
        p [] [ Text $"""That is why we're taking the middle ground. We do NOT transfer private keys over network, but we generate then deterministically. That means, that all you need to remember is {bo "how"} you generated that key. Then, you will be able to recover access to your data from any device even if all devices you had are lost.""" ]
        p [] [
            ol [] [
                li [] [ Text $"""Install {ur "https://github.com/skeeto/passphrase2pgp" "passphrase2pgp"} on both computers, it allows to create deterministic keys""" ]
                li [] [ 
                    Text $"""Create keys"""
                    ol [] [
                        li [] [ Text $"""Make up some {it "very"} secret passphrase. It should be long and stored somewhere very secure. This will be a generation seed for your keys""" ]
                        li [] [
                            Text $"""Run {co "passphrase2pgp --subkey --protect=2 --uid \"user-d\" | gpg --import"}"""
                            ul [] [
                                li [] [ Text $"""It will ask you for a passphrase - input the one you made it twice""" ]
                                li [] [ Text $"""It will then ask you about {co "passphrase [protection]"} - it's the password you're going to write whenever you access your passwords/gpg files""" ]
                                li [] [ Text $"""{co "--subkey"} is needed to encrypt and decrypt. {co "--protect=2"} is needed to create a generation passphrase different from the protection one""" ]
                            ]
                        ]
                        li [] [ Text $"""Same way generate them on the other computer (using the same passphrase, but don't transfer it over network)""" ]
                    ]
                ]
                li [] [ 
                    Text $"""Re-init {co "pass"} using new Key ID (you can keep the old key ID)"""
                    ol [] [
                        li [] [ Text $"""{co "pass init \"user1\" \"user-d\""}""" ]
                        li [] [ Text $"""That allows to keep your old key ID just in case, but it's also now encrypted with deterministic key""" ]
                    ]
                ]
                li [] [ Text $"""Push your changes, pull to another computer, test""" ]
            ]
        ]
        p [] [ Text $"""Push your changes, pull to another computer, test""" ]


        h2 [] [ anc "mobile"; Text $"""3. Access & add passwords from your android phone""" ]
        p [] [
            ol [] [
                li [] [ Text $"""Install [Password Store](https://github.com/android-password-store/Android-Password-Store#readme)""" ]
                li [] [ Text $"""Install {ur "https://www.openkeychain.org" "OpenkeyChain"}""" ]
                li [] [ Text $"""Open Password Store app, generate SSH and GPG keys (make sure to encrypt both)""" ]
                li [] [ Text $"""Upload your {bo "public"} SSH key to github or whatever your remote server is""" ]
                li [] [ 
                    Text $"""Upload your GPG key to your PC and re-encrypt your passwords by adding your newly generated key""" 
                    ol [] [
                        li [] [ Text $"""E. g. {co "pass init \"johny-pc <johny@member.fsf.org>\""} -> {co "pass init \"johny-pc <johny@member.fsf.org>\" \"johny-phone <johny@member.fsf.org>\""}""" ]
                        li [] [ Text $"""Sync from your PC to remote server""" ]
                    ]
                ]
                li [] [ Text $"""Sync from remote server""" ]
                li [] [ Text $"""You're set""" ]
            ]
        ]


        h2 [] [ anc "faq"; Text "FAQ" ]
        p [] [
            ul [] [
                li [] [ 
                    p [] [
                        Text $"""{bo "Q"}: But wait, what {bo "if"} the hacker somehow stole one of my devices with this private key. Then he will access to the most important key that I deterministically generated, and thus, all data!"""
                    ]
                    p [] [
                        Text $"""{bo "A"}: Yes. But even if you generate the key randomly on every new device, the hacker will access the data the same way. It is important to encrypt the private key itself, but if the hacker somehow got access to private key, encryption passphrase, and the repo with passwords - it's over. At least, in my setup. """
                    ]
                ]
                li [] [
                    p [] [
                        Text $"""{bo "Q"}: Why not KeePassXc, BitWarden, and alike?"""
                    ]
                    p [] [
                        Text $"""{bo "A"}: First of all I should say, that these are great options. They both are free and self-hosted. But I prefer {co "pass"}. """
                    ]
                    p [] [
                        Text $"""{co "pass"} follows Unix philosophy, as it is entirely modular. It is originally just a small bash script, which utilizes GnuPG, tree, and git. That means, you're entirely free to replace those "dependencies" with whatever you like. It also means that you're not really {it "dependent"} on {co "pass"}, because the generated "key database" is literally a folder with .gpg files and a file with Key IDs listed. So you can decrypt your passwords without {co "pass"}. Thanks to its modularity, it is very easy to write a {co "pass"} client for any OS. As a result, we got clients for all OS, even iOS."""
                    ]
                ]
                li [] [
                    p [] [
                        Text $"""{bo "Q"}: What are advantages over other password managers in terms of security?"""
                    ]
                    p [] [
                        Text $"""{bo "A"}: Assymetric encryption. Unlike most if not all other password managers, this one allows you to encrypt files assymetrically - it means, that even having both your primary password {it "and"} the folder with encrypted passwords, nobody will be able to access them. So unlike regular pw managers, there are three components in your password workflow: folder with passwords, private key, password from the key. It is necessary to have all three components to unlock a password. """
                    ]
                ]
            ]
        ]
    ]
}
