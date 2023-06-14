export interface BurriedList {
    burriedId: number;
    burriedName: string;
    burriedLastname: string;
    dateOfBirth: Date;
    dateOfDeath: Date;

    burialDate: Date;
}

export interface Grave {
    graveId: number;
    x: number;
    y: number;
    status: string;
    validUntil: Date;
}