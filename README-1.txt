Assumptions:
  • User input is assumed to be in 12 hours format, since it'd be pointless to use 24 hours format.

  • Clock hands are assumed to be snapped to discrete points according to this distribution: 
      > Minutes hand is always standing on a point of 60 unique points, each is 6 degrees away from the other.
      > Hours hand is always standing on a point of 360 unique points, each is 1 degree away from the other.

Calculation methodology:
  • Since the minutes hands' revolution determines the hours as well, we will calculate the input based on minutes, so we convert hours to minutes.

  • The minutes hand completes a full revolution every 60 minutes, which means 6 degrees each minute, and the hours hand completes a full revolution 
    every 720 minutes, or .5 degrees per minute.

  • To calculate the rotation amount from origin (00:00 or 12:00) we simply multiply the angle increment amount by its corresponding hand, 
    so if the input given by the user is H hours and M minutes, the hours hand have moved ( (H*60 + M) * 0.5) degrees, and the minutes hand will have 
    moved (( H*60 + M) * 6) degrees.

  • To get the lesser angle between the clock hands we simply subtract the two angles and get the absolute value (in case the subtrahend is greater 
    than the minuned), then we decide whether the difference is greater than 180 (since the greatest lesser angle between two vectors is half the full
    revolution around their intersection), if no then we simply return it as the final result, if yes then we subtract the difference from 360 and return
    the result.
