function [Precision,Recall,Accuracy] = PerformanceEvaluation(ContTable)
All =ContTable(1,1)+ContTable(1,2)+ContTable(2,1)+ContTable(2,2);
Precision = ((ContTable(1,1))/(ContTable(1,1)+ContTable(2,1)));
Recall = ((ContTable(1,1)) / (ContTable(1,1)+ContTable(1,2)));
Accuracy = ((ContTable(1,1)+ContTable(2,2))/All);

end

