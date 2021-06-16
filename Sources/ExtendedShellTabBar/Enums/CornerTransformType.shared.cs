using System;
namespace ExtendedShellTabBar.Enums
{
	[Flags]
	public enum CornerTransformType
	{
		TopLeftRounded = 0x10,
		TopRightRounded = 0x20,
		BottomLeftRounded = 0x40,
		BottomRightRounded = 0x80,

		AllRounded = TopLeftRounded | TopRightRounded | BottomLeftRounded | BottomRightRounded,
		LeftRounded = TopLeftRounded | BottomLeftRounded,
		RightRounded = TopRightRounded | BottomRightRounded,
		TopRounded = TopLeftRounded | TopRightRounded,
		BottomRounded = BottomLeftRounded | BottomRightRounded,
	}
}
