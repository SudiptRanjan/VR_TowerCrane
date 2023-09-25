public static class Events 
{
	

	public delegate void OnMovement( float yDirection);
	public static OnMovement onPlayerMoves;

    public delegate void OnRotate(float yDirectionRotate);
    public static OnRotate onPlayerRotate;

    public delegate void OnRopeLengthChange(float ropeValue);
	public static OnRopeLengthChange onRopeValueChange;

	public delegate void OnHookAttach(bool attached);
	public static OnHookAttach onHookAttachToObject;

	public delegate void OnHookDetached(bool detached);
	public static OnHookDetached onHookDetachedToObject;

	public delegate void OnClickRed(bool clicked);
	public static OnClickRed onClickRedButton;

}
