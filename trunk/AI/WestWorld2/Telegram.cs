namespace WestWorld2 {
    public class Telegram {
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public MessageType MessageType { get; set; }
        public double DispatchTime { get; set; }
        public object ExtraData { get; set; }

        public T GetData<T>() where T:class { return ExtraData as T; }

        public override string ToString() { return string.Format("time: {0} Sender: {1} Receiver: {2} Msg: {3}", DispatchTime, Sender, Receiver, MessageType); }
    }
}
