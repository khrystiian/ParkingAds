export class Payment{
    base64StringReceipt: string;
    fullname: string;
    email: string;
    address: string;
    pLocation: string;
    pTime: string;
    nPlate: string;
    
    constructor(Fullname: string, Email: string, Address: string, PLocation: string, PTime: string, NPlate: string){
        this.fullname = Fullname;
        this.email = Email;
        this.address = Address;
        this.pLocation = PLocation;
        this.pTime = PTime;
        this.nPlate = NPlate;
    }
}