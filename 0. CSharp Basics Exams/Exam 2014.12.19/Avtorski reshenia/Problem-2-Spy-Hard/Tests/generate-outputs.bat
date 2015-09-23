csc *.cs
FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    SpyHard.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
