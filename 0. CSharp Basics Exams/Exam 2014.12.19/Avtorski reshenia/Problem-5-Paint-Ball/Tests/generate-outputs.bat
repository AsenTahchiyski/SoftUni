csc *.cs
FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    PaintBall-bitwise.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
