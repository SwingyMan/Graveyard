export interface BurriedList {
    burriedId: number;
    burriedName: string;
    burriedLastname: string;
    dateOfBirth: Date;
    dateOfDeath: Date;

    burialDate: Date;
}

export interface GraveList {
    graveId: number;
    positionX: number;
    positionY: number;
    status: string;
    validUntil: Date;
    burriedId: number;
}