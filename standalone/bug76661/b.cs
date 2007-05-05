using System;

namespace b {
    public class SomeClass {
        public SomeClass() {
        }

        public string Test() {
            c.SomeClass c = new c.SomeClass();
            return "ok b - " + c.Test();
        }
    }
}
