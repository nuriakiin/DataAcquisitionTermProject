function [BinaryMatrix] = ConvertBinary(BinaryEdited)

    BinaryEdited(BinaryEdited==1)=0;
    BinaryEdited(BinaryEdited==2)=0;
    BinaryEdited(BinaryEdited==3)=0;
    BinaryEdited(BinaryEdited==4)=1;
    BinaryEdited(BinaryEdited==5)=1;

BinaryMatrix = BinaryEdited;

end

