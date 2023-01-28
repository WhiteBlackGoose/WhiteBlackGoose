{ pkgs ? import <nixpkgs> {} }:
  pkgs.mkShell {
    nativeBuildInputs = [ pkgs.dotnetCorePackages.sdk_6_0 ];
    shellHook = ''
      DOTNET_ROOT="${pkgs.dotnetCorePackages.sdk_6_0}";
    '';
}
