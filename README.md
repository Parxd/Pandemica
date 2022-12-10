# Pandemica 🔬🦠

Pandemica is a SIR model built with C++ to visualize the spreading of a simulated epidemic/pandemic. 

The [SIR model](https://en.wikipedia.org/wiki/Compartmental_models_in_epidemiology) (Susceptible, Infected, Recovered) is widely known in epidemiology for its simplicity yet accuracy in disease modeling.

A simple summary is as follows:

Provided *t* is time in some arbitrary unit...
* S(t) is the number of __susceptible__ individuals
* I(t) is the number of __infected__ individuals
* R(t) is the number of __recovered__ indivduals
* N is the total number of indivudals in the population being studied

```math
S(t) + I(t) + R(t) = N
```

A system of differential equations is used:
```math
\frac{dS}{dt} = -aS(t)I(t)
```

```math
\frac{dI}{dt} = aS(t)I(t) - bI(t)
```

```math
\frac{dR}{dt} = bI(t)
```
