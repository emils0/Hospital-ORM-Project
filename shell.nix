with import <nixpkgs> {};
  pkgs.mkShell rec {
    dotnetPkg = with dotnetCorePackages;
      combinePackages [
        sdk_6_0
      ];

    deps = [
      zlib
      zlib.dev
      openssl
      dotnetPkg
    ];

    NIX_LD_LIBRARY_PATH = lib.makeLibraryPath ([
        stdenv.cc.cc
      ]
      ++ deps);
    NIX_LD = "${pkgs.stdenv.cc.libc_bin}/bin/ld.so";
    nativeBuildInputs =
      [
      ]
      ++ deps;

    shellHook = ''
      DOTNET_ROOT="${dotnetPkg}";
    '';
  }