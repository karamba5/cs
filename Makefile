OBJ = envp.as
ASFLAGS = -c -g --gdwarf-2
LDFLAGS = -static
DEPS = defs.h


all: $(OBJ)
        as --gdwarf-2 -o $(OBJ).o -c $(OBJ)
        ld $(LDFLAGS) -o envp $(OBJ).o

.PHONY: clean

clean:
        rm $(OBJ).o envp