#if UNITY_IMAGECONVERSION_ENABLED
#if UNITY_EDITOR
using UnityEngine;

namespace MyBox.EditorTools {
	public static class MyIconPresets {
		public static Texture2D IconReload16 => ImageStringConverter.ImageFromString(IconReload, 16, 16);

		public static Texture2D IconReload32 => ImageStringConverter.ImageFromString(IconReload, 32, 32);

		public static Texture2D IconReload64 => ImageStringConverter.ImageFromString(IconReload, 64, 64);

		public static Texture2D IconEye16 => ImageStringConverter.ImageFromString(IconEye, 16, 16);


		public static Texture2D IconEye32 => ImageStringConverter.ImageFromString(IconEye, 32, 32);

		public static Texture2D IconEyeCrossed16 => ImageStringConverter.ImageFromString(IconEyeCrossed, 16, 16);

		public static Texture2D IconEyeCrossed32 => ImageStringConverter.ImageFromString(IconEyeCrossed, 32, 32);


		private const string IconReload =
			"iVBORw0KGgoAAAANSUhEUgAAAIAAAACACAMAAAD04JH5AAAArlBMVEUAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABeyFOlAAAAOXRSTlMA5ODTwwz7gEAF6PHbvRYQ9ZdGJAnOnhz318mqo3ZsWVEhGOy3cTUuE4t7XlQrrmZjSzuykqiGMigneNQWAAAEbUlEQVR42uzX2XaiQBSF4QMyKzggiKgMiopGNMZM+/1frG+6e7ksBLEq5sbvBfjhVFFAT09PT09Pj2ZGJIaafhlxNNN1fbs8JG+FQzfpTkD80uPSt+Ueziy80/vrF9VZK7CIkxtNOii3UN53KlVILEAmHvkhk1BF6/QNk66YBQAkul+xkVEvUA6j0vFPAa4Aw9dwI2nm0qXvEFwBbz6akJcXgzhK4AlQP3toSDnSmZkGngCjheZ6fn62+/+ThN1+vdbu7945gSfgW8HdNkMiKkLwBLxY4JAVtLPAEdDdg491AjgCRgq48QSkHn41YOQBvxkwauEHSBzXf3CAjzq9Tmhnme1J2k8EvFZfe+xHAzdX1eFQ7TrrRM8sTWzAKsB1rY2hMhOLPyyBAeoYV2WxSaXWfVlYwBTXKDFd5+ptMQExrrCWat1nW1tAQCqhlDZ1qc7QFhAwQanFjmoVSsAfMECpzopqHSUBa2DooYw3olpb1JLuXYGhc8uPn4gAs4US45TqOBmEBOxQom1QnSKEmAAbJV7rB2dBTMBbAJZCdT6FnYY+WNoXVVMnEBXgdMDSqdoqhLCAGCx5TpVeFhAX0AdrSVXcPpqQmk9gnFOVSJIFBhwbPwDK89R42ZzGmpAAHQypSzcYzr8TfT8ONL4Acw/GB93MVItk++FZvbsDHBmMHTWVDpZ9Re7dE7AGY5HTXVLj8J612g0DYjBOxMFZJdtpuLg9YAvGlnh13cHMV/5VWE1fQwkJoc6NqG/LbQRUhd0E2poE6q4inaoo7JqZ0yO1cCnM6ZHYk8BW6ZFkXNqb9Eh/2rXTJTWBKArAB1AWQVTcF1xw1DKacRmXnPd/sfxMKt0INEhVpvgegOpLF7e4p1scK6YOXvl2b8ATw4A6csn/FbRQpprsf7BMX/zXqIsyDSgIUCaLghBlOlAwRZm2FGh1lGgojrimjdLII64OyiOfC3yUKKDIgrK9ZfeQyVCnwOjlKMf1PkO7hfRmFJ2QhZj2jLzBaesjnRNFhgMlyxH/GA/m1yGSRRqLmg1ahlDJ3fqltAftHRRYanFbMKKoCZFS3Nb3kchQWbjI71NxM8+UcLfI6E6JxgrJejoltC4ymZNUbesHyujCCrI/w40AKJ8XjLd56+cD6dgmZdwNRPE3hvL09A7lbj5SeNYoFyCt1Zpy/QCJrDblZg5SW5iM0UnopcsmY3gtZDBjHO02RKxgajLOAlm0PMbSH7u6NLNdNtuM1UE21zbjmc3QjvC3Xnf5MPjCpIeMznxtPN2fLvb2+bwGx83to8GXtG7eMU3OdNdum8ncK7Kr11iYI1REfRYkhJquwULcICj1Jtce6pw982ockcvcZC7GDjkFBnOYRsgtmlGVG6IQc51KajYK0p0yu3WIAh08ZjT4iUL5mwbTM2sXFG74w2A6bm3p4B2cw+eaicYdG++zDb9cvqDPDhHey9md72PKtJtWsEIZHH+3sGbNieHpmqbp3rg/+ehsLqs6KpVKpVL5D/0GR6Q1W4O7GC4AAAAASUVORK5CYII=";

		private const string IconEye =
			"iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAllBMVEUAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA6C80qAAAAMXRSTlMA/AQdmFkx8dyRhYBwSCEW6cG7s653X0A2LPTf2NTHmpRMGRMG0c3Jw39osKWgiTwpnSU/9gAAAQRJREFUOMvlkVdyhDAQRDVIZDaQc/Cy2bHvfzljSYUpihvs+1GrZrrno9nLYRSBiMMwFkFhbIyt/oiZo7DW4wgAtR9eGvifFwIQl4vx+YuAW3ZgmjHrAPLmQ6cbcM2l3JvZXor8CnTasa9BqUoSmOiVMyU4XPpr2MrOBCRC/XIbzpRhdLAtHQUFcfUvbNwN5oF2TGFCYzLFjuCzx/9Ctl54A1JmhKiK7RPfFaLpOTiwdUYPyaD9FZrxT3AH5BuyDUEADVKfPaA5qdXDHWhVCDdNruwNEI5zjx4Bl4AzDQ9agB7LTssYE07i+r6b1Jh4/1n1WQ7Lut2SbWA93SSKEvdpsZfjF8DaIuCDeOKkAAAAAElFTkSuQmCC";

		private const string IconEyeCrossed =
			"iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAilBMVEUAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAATAggvAAAALXRSTlMABPkXHfHWyeremYBvMvTPd1lIQAy0r6SRhV5MIffBuytoOjYnEOPDtpSKRBNc009oAAABPklEQVQ4y7WS13LDIBBFF9R7r46KS1xz///3IgEztpUMbz5PK+2eiwTQ5/jemdp+eR/8b02fpRxXzQDrY7gPTcDBRdyzP9ox9KtxrPxw54Cn237ku3ihKjftCQC3my4Ng8YVE/Nr+J0DTm/Ih3DAOQF4x0hhOEBSiPIr60MLbkFFsigGyZceeCplHyvDfnVTDs8UvgdL6iT7SGR2YcEzFsuBFakoSLg6haOFC6MOPCdJBkVGkpwjoOA50G8HdkBKbER8/H+JQ4xJfaTMiCwIbsqPYf+shemBB2wJSKR/Y+KXO8A21EZdljovG6CZs8yUug2MwpfTHHABRy1uhjZE6pO5wsK5boOgrT0s1Cd642HhBbed6Z2TjSGM9m09TXW7j2iL6QB+qbnjDXA1NHc0j9ez13Cwk4J0lNGJ0cf4BX2sKFr3AYx/AAAAAElFTkSuQmCC";
	}
}
#endif
#endif