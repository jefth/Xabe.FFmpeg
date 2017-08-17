﻿using System;
using System.IO;
using Xabe.FFMpeg.Enums;
using Xunit;

namespace Xabe.FFMpeg.Test
{
    public class ConversionTests
    {
        private static readonly FileInfo SampleMkvVideo = new FileInfo(Path.Combine(Environment.CurrentDirectory, "Resources", "sampleMkv.mkv"));

        [Fact]
        public void Test()
        {
            string outputPath = Path.ChangeExtension(Path.GetTempFileName(), ".mp4");
            bool conversionResult = new Conversion()
                .SetInput(SampleMkvVideo)
                .SetSpeed(Speed.UltraFast)
                .UseMultiThread(true)
                .SetOutput(outputPath)
                .SetChannels(Channel.Both)
                .SetScale(VideoSize.Original)
                .SetVideo(VideoCodec.LibX264, 2400)
                .SetAudio(AudioCodec.Aac, AudioQuality.Ultra)
                .Start();
            Assert.True(conversionResult);
        }
    }
}