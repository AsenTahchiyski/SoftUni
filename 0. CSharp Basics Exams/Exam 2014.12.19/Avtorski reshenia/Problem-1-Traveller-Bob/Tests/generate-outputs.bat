csc *.cs
FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    TravellerBob.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
