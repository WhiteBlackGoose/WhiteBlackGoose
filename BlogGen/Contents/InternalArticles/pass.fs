module InternalArticles.Pass

open Giraffe.ViewEngine
open InternalArticleDef

let page = {
    title = "Pass - password manager for geeks"
    contents = [
        h2 [] [ anc "why"; Text "Why?" ]
        p [] [
            ul [] [
                li [] [ Text "✔️  CLI interface only, no need for GUI" ]
                li [] [ Text "✔️  Works natively on Unix-like systems" ]
                li [] [ Text "✔️  Has many clients for mainstream OS" ]
                li [] [ Text "✔️  Only famous FOSS tools (used utils: `git`, `pass`, `gpg`, `openssh`, `passphrase2pgp`)" ]
                li [] [ Text "✔️  No Google/Facebook account or other BS integration, your credentials are yours and stored by you on your computer" ]
                li [] [ Text "✔️  Knowing your primary password is not enough to access your passwords" ]
                li [] [ Text "✔️  Still can sync among devices" ]
                li [] [ Text "✔️  You control where your backup stored (and it's encrypted too)" ]
                li [] [ Text "X That's 100x more complicated to set up than most crappy password managers you'd find on the internet"  ]
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
                    Text $"""`gpg --full-generate-key` to generate key using GPG. In the end it will return something like `myname <mymail@quack.org>`, remember this, it's your *Key ID*. Let it be `user1` for now (assuming you skipped mail). You will be asked to input a passphrase - that's what your private key will be decrypted with, make sure to remember it!""" ]
                li [] [ 
                    Text $"""`pass init user1` inits your password store (input the key ID from the previous step).""" ]
                li [] [ 
                    Text $"""`pass insert website/username` creates a prompt where you input your password.""" ]
                li [] [
                    Text $"""`pass website/username` retrieves it. `pass -c website/username` retrives it into clipboard.""" ]
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
                li [] [ Text $"""Install `git`""" ]
                li [] [ Text $"""Init repo: `pass git init`""" ]
                li [] [ 
                    Text "If you want to use `github` to sync:" 
                    ol [] [
                        li [] [ 
                            Text "I highly recommend using an SSH key as access token"
                            ol [] [
                                li [] [ Text $"""Set your username: `git --global user.name User1`""" ]
                                li [] [ Text $"""Set your email: `git --global user.email user@quack.org`""" ]
                                li [] [ Text $"""Generate an SSH keypair with ssh-keygen""" ]
                                li [] [ Text $"""Copy the content of the public key (e. g. `cat ~/.ssh/id_rsa.pub | xclip -sel clip`)""" ]
                                li [] [ Text $"""Go to github.com -> settings -> SSH keys -> new SSH key, copy the key into the text area and save""" ]
                            ]
                        ]
                        li [] [ Text $"""Create an empty repo""" ]
                        li [] [ Text $"""Locally do `pass git remote add github git@github.com:user1/myrepo.git` (you don't have to name it `github`, of course)""" ]
                        li [] [ Text $"""`pass git push github master`""" ]
                    ]
                ]
                li [] [ 
                    Text $"""If you want to use your local server to sync:""" 
                    ol [] [
                        li [] [ Text $"""Assuming you access it over ssh""" ]
                        li [] [ Text $"""Create a repo on your remote server this way: `git init --bare pass-repo`""" ]
                        li [] [ Text $"""Locally do `pass git remote add home ssh://user1@your-ip:your-ssh-port/path/to/pass-repo`""" ]
                        li [] [ Text $"""`pass git push home master`""" ]
                    ]
                ]
            ]
        ]
        p [] [ Text $"""I personally use both. Your passwords can only decrypted using your private keys that **you never send** to anyone. We can sync your passwords without them. As for now, we set up git, let's proceed by adding another device.""" ]

        h3 [] [ anc "add-comp"; Text "2.2 Add new computer" ]
        p [] [ Text $"""Let your current computer be `A` and the new one is `B`.""" ]
        p [] [
            ol [] [
                li [] [ 
                    Text $"""Key setup""" 
                    ol [] [
                        li [] [ Text $"""Generate a new GPG key on computer `B` with a **different** key ID (`gpg --full-generate-key`)""" ]
                        li [] [ Text $"""Export **public** key, e. g. `gpg --export "user2" > pub.k` and copy `user2.pub` to computer `A`""" ]
                        li [] [ Text $"""Export **public** key of computer **A** to computer `B` (like step 2-3, but the other way around)""" ]
                        li [] [ Text $"""On computer `A`, import this key: `gpg --import user2.pub`""" ]
                    ]
                ]
                li [] [ Text $"""Reencrypt everthing on computer `A`: `pass init "user1" "user2"`""" ]
                li [] [ 
                    Text "Push" 
                    ol [] [
                        li [] [ Text$"""If you sync with github: `pass git push github master`""" ]
                        li [] [ Text$"""If you sync with your local computer: `pass git push home master`""" ]
                    ]
                ]
                li [] [ Text $"""Init the password store and git repo on computer `B` (`pass init "user1" "user2" && pass git init`)""" ]
                li [] [ 
                    Text $"""Add remote (same as in **2.1**)""" 
                    ol [] [
                        li [] [ Text $"""For github: `pass git remote add github https://github.com/user1/myrepo`""" ]
                        li [] [ Text $"""For local computer: `pass git remote add home ssh://user1@your-ip:your-ssh-port/path/to/pass-repo""" ]
                    ]
                ]
                li [] [ Text $"""Reset to it (`pass git reset --hard github/master` for github and `pass git reset --hard home/master` for home server)""" ]
            ]
        ]
        p [] [ Text $"""Done. You can now retrieve passwords and sync them between two computers, see how simple & user-friendly it all is?""" ]
    ]
}
