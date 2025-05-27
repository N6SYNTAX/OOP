print("Helloworlsd")
import tracemalloc
import time


class Counter:
    def __init__(self, _name, _count = 0):
        self.name = _name
        self.count = _count

    def Increment(self):
        self.count += 1

    def Reset(self):
        self.count = 0

    def Ticks(self):
        return self.count

    
      
Count = Counter("Hour Counter")

print(Count.name)


class Clock:
    def __init__(self, hr = Counter("Hour Counter"),
                min = Counter("Minute Counter"), 
                sec= Counter("Second Counter")):
        self.hr = hr
        self.min = min
        self.sec = sec

        
    def Restart(self):
        self.hr.Reset()
        self.min.Reset()
        self.sec.Reset()


    def Tick(self):
        self.sec.Increment()

        if (self.sec.Ticks() == 60):
            self.sec.Reset()
            self.min.Increment()
            
            if (self.min.Ticks() == 60):
            
                self.min.Reset()
                if (self.hr.Ticks() < 24):
                
                    self.hr.Increment()
                
                else:
                
                    self.hr.Reset()
                
    def Display(self):
        h = f"{self.hr.Ticks():02}"
        m = f"{self.min.Ticks():02}"
        s = f"{self.sec.Ticks():02}"

        return f"{h}:{m}:{s}"

            

        
    

MyClock = Clock()

tracemalloc.start()
start_time = time.perf_counter()


for i in range(10000):
    MyClock.Tick()

end_time = time.perf_counter()



print (MyClock.Display())
MyClock.Restart()
print (MyClock.Display())


print(f"Elapsed Time: {(end_time - start_time) * 1000:.2f} ms")

current, peak = tracemalloc.get_traced_memory()
print(f"Current memory usage: {current / 1024:.2f} KB")
print(f"Peak memory usage: {peak / 1024:.2f} KB")
tracemalloc.stop()
