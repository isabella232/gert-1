typedef void (* Fptr ) (const char * arg, ...);

Fptr my_fptr;

void set_fptr (Fptr fptr) {
  my_fptr = fptr;
}

