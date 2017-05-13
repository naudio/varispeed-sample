# Varispeed NAudio Playback Sample

This sample shows how to achieve varispeed playback in NAudio by making use of the [SoundTouch library](http://www.surina.net/soundtouch/README.html). It can modify playback speed on its own, or tempo which maintains the same pitch at any speed.

The `VarispeedSampleProvider` implements NAudio's `ISampleProvider` and calls into SoundTouch to perform the speed change. Read more about this project [here](http://markheath.net/post/varispeed-naudio-soundtouch)
