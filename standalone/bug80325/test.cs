#if A1

#elif A2
#  warning A2
#  if B2
#    warning A1->B2
#    define A1B2
#  else
#    warning A2->else
#  endif
#else
#  warning else
#endif
