#ZTable Generator 

This mini project was written to generate a ZTable using custom ranges and precision using a normal cumulative distribution function that gives the probability that a random variable X will take a value less than or equal to X where X is normally distributed, in other words to calculate the percentage area under a bell curve of a given Z score.

$$
\varphi\left(x\right)\ =\ \frac{1}{\sqrt{2\pi}}\ \int_{-\infty}^{x}e^\frac{-t^2}{2}dt
$$

Which we approximate using Abramowitz and Stegun approximation formula, which is accurate to within 10^-7 for all values of x

    Φ(x) = (1 / 2π^0.5) * e^(-x^2/2) * (a1t + a2t^2 + a3t^3 + a4t^4 + a5t^5)
    where t=1/(1+px) and p=0.2316419. The coefficients a1 to a5 are constants that depend on p.
    a1 = 0.3193815, a2 = -0.3565638, a3 = 1.781478, a4 = -1.821256, a5 = 1.330274
    C1 = 1 / Math.Sqrt(2 * Math.PI) = 0.3989422804014327

Calculated as 

 ```csharp
            double t = 1 / (1 + p * Math.Abs(x));
            double d = 0.3989423 * Math.Exp(-x * x / 2);
            double prob = d * t * (a1 + t * (a2 + t * (a3 + t * (a4 + t * a5))));
```

The default vertical range was chosen according to the Empirical rule aka the 3 segma rules 68-95-99.7 for -3.4 -> 3.4 to cover 99.7%

|z| 0|0.01 |0.02 |0.03 |0.04 |0.05 |0.06 |0.07 |0.08 |0.09 |
| ------- | ------- | ------- | ------- | ------- | ------- | ------- | ------- | ------- | ------- | ------- |
|**0.0**| 0.5     | 0.504   | 0.508   | 0.512   | 0.516   | 0.5199  | 0.5239  | 0.5279  | 0.5319  | 0.5359  |
|**0.1**| 0.5398  | 0.5438  | 0.5478  | 0.5517  | 0.5557  | 0.5596  | 0.5636  | 0.5675  | 0.5714  | 0.5753  |
|**0.2**| 0.5793  | 0.5832  | 0.5871  | 0.591   | 0.5948  | 0.5987  | 0.6026  | 0.6064  | 0.6103  | 0.6141  |
|**0.3**| 0.6179  | 0.6217  | 0.6255  | 0.6293  | 0.6331  | 0.6368  | 0.6406  | 0.6443  | 0.648   | 0.6517  |
|**0.4**| 0.6554  | 0.6591  | 0.6628  | 0.6664  | 0.67    | 0.6736  | 0.6772  | 0.6808  | 0.6844  | 0.6879  |
|**0.5**| 0.6915  | 0.695   | 0.6985  | 0.7019  | 0.7054  | 0.7088  | 0.7123  | 0.7157  | 0.719   | 0.7224  |
|**0.6**| 0.7257  | 0.7291  | 0.7324  | 0.7357  | 0.7389  | 0.7422  | 0.7454  | 0.7486  | 0.7517  | 0.7549  |
|**0.7**| 0.758   | 0.7611  | 0.7642  | 0.7673  | 0.7704  | 0.7734  | 0.7764  | 0.7794  | 0.7823  | 0.7852  |
|**0.8**| 0.7881  | 0.791   | 0.7939  | 0.7967  | 0.7995  | 0.8023  | 0.8051  | 0.8078  | 0.8106  | 0.8133  |
|**0.9**| 0.8159  | 0.8186  | 0.8212  | 0.8238  | 0.8264  | 0.8289  | 0.8315  | 0.834   | 0.8365  | 0.8389  |
|**1.0**| 0.8413  | 0.8438  | 0.8461  | 0.8485  | 0.8508  | 0.8531  | 0.8554  | 0.8577  | 0.8599  | 0.8621  |
...
...




Feel free to change the ranges, include or exclude negative range, p(s) and a(s); nevertheless try to run the unit tests to make sure you pass the tests
- TestNormalCDF
- TestRangeAroundZero
- TestRangeAboveZero
- TestCreateRange
